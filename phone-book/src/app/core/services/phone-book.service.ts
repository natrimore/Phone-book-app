import { Injectable } from "@angular/core";
import { UrlHelper } from "../helpers/url.helper";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { GridResult } from "../models/base/grid-result.model";
import { PhoneBook } from "../models/phone-book/phone-book";
import { GridState } from "../configs/grid-state";
import { BrowsePhoneBook } from "../models/phone-book/browse-phone-book";

@Injectable({
  providedIn: "root",
})
export class PhoneBookService {
  private readonly baseUrl = UrlHelper.settings.apiUrl + "/api/Phone/";

  constructor(private http: HttpClient) {}

  getAll(search: BrowsePhoneBook): Observable<{ result: PhoneBook[] }> {
    return this.http.get<{ result: PhoneBook[] }>(
      this.baseUrl + `getAll?searchKey=${search.searchKey}`
    );
  }

  create(model: PhoneBook) {
    return this.http.post(this.baseUrl + "create", model, {
      observe: "response",
    });
  }

  update(model: PhoneBook) {
    return this.http.put(this.baseUrl + "update", model, {
      observe: "response",
    });
  }

  delete(id: number) {
    return this.http.delete(this.baseUrl + `delete?id=${id}`);
  }
}
