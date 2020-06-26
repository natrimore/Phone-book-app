import { Observable, throwError, of } from "rxjs";
import { Injectable } from "@angular/core";
import {
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
  HttpHeaderResponse,
  HttpSentEvent,
  HttpProgressEvent,
  HttpResponse,
  HttpUserEvent,
} from "@angular/common/http";
import { catchError, map, switchMap } from "rxjs/operators";
import { ToastrService } from "ngx-toastr";

/**
 *
 */
@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  /**
   *
   * @param auth
   * @param router
   */
  constructor(private toastrService: ToastrService) {}

  /**
   *
   * @param req
   * @param next
   */
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<
    | HttpSentEvent
    | HttpHeaderResponse
    | HttpProgressEvent
    | HttpResponse<any>
    | HttpUserEvent<any>
  > {
    return next.handle(req).pipe(
      catchError((err) => {
        let errors = ["Произошла неожиданная ошибка."];
        if (err) errors = this.formatErrors(err);

        this.toastrService.warning(errors[0], err.status);
        return throwError(errors);
      })
    );
  }

  /**
   *
   * @param err
   */
  private formatErrors(err) {
    if (typeof err.error === "string") {
      err.error = JSON.parse(err.error);
    }
    if (err.error && err.error.error) {
      return [err.error.error.message];
    }
    if (err.error && err.error.message) {
      return [err.error.message];
    }
    if (err.message) {
      return [err.message];
    }
    return ["Something went wrong"];
  }
}
