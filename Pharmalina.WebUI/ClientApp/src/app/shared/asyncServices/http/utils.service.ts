import { Headers, URLSearchParams, RequestOptions, Request, Response } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { HttpService } from "./http.service";

export function methodBuilder(method: number) {
  return function (url: string) {
    return function (target: HttpService, propertyKey: string, descriptor: any) {

      let pPath = target[`${propertyKey}_Path_parameters`],
        pQuery = target[`${propertyKey}_Query_parameters`],
        pBody = target[`${propertyKey}_Body_parameters`],
        pHeader = target[`${propertyKey}_Header_parameters`];

      descriptor.value = function (...args: any[]) {
        let body: string = createBody(pBody, descriptor, args);
        let resUrl: string = createPath(url, pPath, args);
        let search: URLSearchParams = createQuery(pQuery, args);
        let headers: Headers = createHeaders(pHeader, descriptor, this.getDefaultHeaders(), args);

        // Request options
        let options = new RequestOptions({
          method,
          url: this.getBaseUrl() + resUrl,
          headers,
          body,
          search
        });

        let req = new Request(options);

        // intercept the request
        this.requestInterceptor(req);
        // make the request and store the observable for later transformation
        let observable: Observable<Response> = this.http.request(req);

        // intercept the response
        observable = this.responseInterceptor(observable, descriptor.adapter);

        return observable;
      };

      return descriptor;
    };
  };
}

export function paramBuilder(paramName: string) {
  return function (key: string) {
    return function (target: HttpService, propertyKey: string | symbol, parameterIndex: number) {
      let metadataKey = '${propertyKey}_${paramName}_parameters';
      let paramObj: any = {
        key: key,
        parameterIndex: parameterIndex
      };

      if (Array.isArray(target[metadataKey])) {target[metadataKey].push(paramObj); } else {target[metadataKey] = [paramObj]; }
    };
  };
}

function createBody(pBody: Array<any>, descriptor: any, args: Array<any>): string {
  if (descriptor.isFormData) {return args[0]; }
  return pBody ? JSON.stringify(args[pBody[0].parameterIndex]) : null;
}

function createPath(url: string, pPath: Array<any>, args: Array<any>): string {
  let resUrl: string = url;

  if (pPath) {
    for (let k in pPath) {
      if (pPath.hasOwnProperty(k)) {
        resUrl = resUrl.replace('{' + pPath[k].key + '}', args[pPath[k].parameterIndex]);
      }
    }
  }

  return resUrl;
}

function createQuery(pQuery: any, args: Array<any>): URLSearchParams {
  let search = new URLSearchParams();

  if (pQuery) {
    pQuery
      .filter(p => args[p.parameterIndex]) // filter out optional parameters
      .forEach(p => {
        let key = p.key;
        let value = args[p.parameterIndex];
        // if the value is a instance of Object, we stringify it
        if (value instanceof Object) {
          value = JSON.stringify(value);
        }
        search.set(encodeURIComponent(key), encodeURIComponent(value));
      });
  }

  return search;
}

function createHeaders(pHeader: any, descriptor: any, defaultHeaders: any, args: Array<any>): Headers {
  let headers = new Headers(defaultHeaders);

  // set method specific headers
  for (let k in descriptor.headers) {
    if (descriptor.headers.hasOwnProperty(k)) {
      if (headers.has(k)) {headers.delete(k); }
      headers.append(k, descriptor.headers[k]);
    }
  }

  // set parameter specific headers
  if (pHeader) {
    for (let k in pHeader) {
      if (pHeader.hasOwnProperty(k)) {
        if (headers.has(k)) {headers.delete(k); }
        headers.append(pHeader[k].key, args[pHeader[k].parameterIndex]);
      }
    }
  }

  return headers;
}