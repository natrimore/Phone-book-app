import { InjectorHelper } from "./injector.helper";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";
// import { AuthService } from '../services/auth/auth.service';
import { ToastrService } from "ngx-toastr";
// import { TranslateService } from '@ngx-translate/core';

/**
 *
 */
export interface KeyValuePair {
  /**
   *
   */
  key: string;

  /**
   *
   */
  value: string;
}

export class ServiceHelper {
  /**
   * Static HTTP client
   */
  static get http(): HttpClient {
    return InjectorHelper.injector.get(HttpClient);
  }

  // /**
  //  *
  //  */
  // static get auth(): AuthService {
  //   return InjectorHelper.injector.get(AuthService);
  // }

  // /**
  //  *
  //  */
  // static get file(): FileService {
  //   return InjectorHelper.injector.get(FileService);
  // }

  /**
   *
   */
  static get toastr(): ToastrService {
    return InjectorHelper.injector.get(ToastrService);
  }

  // /**
  //  *
  //  */
  // static get translate(): TranslateService {
  //   return InjectorHelper.injector.get(TranslateService);
  // }

  /**
   *
   * @param url
   * @param keyMap
   */
  static get<TResponse>(
    url: string,
    keyMap?: KeyValuePair[]
  ): Observable<TResponse> {
    const params = new HttpParams();
    if (keyMap)
      keyMap.forEach((value) => params.append(value.key, value.value));
    return this.http.get<TResponse>(url, { params });
  }

  /**
   *
   * @param url
   */
  static byId<TResponse>(url: string): Observable<TResponse> {
    return this.http.get<TResponse>(url);
  }

  /**
   * Post request
   * @param url
   * @param model
   */
  static post<TResponse>(url: string, model: any): Observable<TResponse> {
    return this.http.post<TResponse>(url, model);
  }

  /**
   * Put request
   * @param url
   * @param model
   */
  static put<TResponse>(url: string, model: any): Observable<TResponse> {
    return this.http.put<TResponse>(url, model);
  }

  /**
   *
   * @param url
   */
  static delete<TResponse>(url: string): Observable<TResponse> {
    return this.http.delete<TResponse>(url);
  }
}
