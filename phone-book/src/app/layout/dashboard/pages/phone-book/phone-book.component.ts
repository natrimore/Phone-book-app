import { Component, OnInit, ViewChild, AfterViewInit } from "@angular/core";
import { PhoneBookService } from "src/app/core/services/phone-book.service";
import { PhoneBook } from "src/app/core/models/phone-book/phone-book";
import { BrowsePhoneBook } from "src/app/core/models/phone-book/browse-phone-book";
import { NgOnDestroy } from "src/app/shared/services/ng-on-destroy.service";
import { takeUntil } from "rxjs/operators";
import { ToastrService } from "ngx-toastr";
import { PhoneBookCreateModalComponent } from "src/app/shared/components/phone-book-create-modal/phone-book-create-modal.component";
import { ServiceHelper } from "src/app/core/helpers/service.helper";

@Component({
  selector: "app-phone-book",
  templateUrl: "./phone-book.component.html",
  styleUrls: ["./phone-book.component.css"],
})
export class PhoneBookComponent implements OnInit, AfterViewInit {
  users: PhoneBook[];
  user: PhoneBook;
  count: number;
  search: BrowsePhoneBook;

  @ViewChild(PhoneBookCreateModalComponent) form: PhoneBookCreateModalComponent;

  selected = [];

  constructor(
    private phoneBookService: PhoneBookService,
    private onDestroy: NgOnDestroy,
    private toastrService: ToastrService
  ) {
    this.users = [];
    this.count = 0;
    this.search = new BrowsePhoneBook();
  }
  ngAfterViewInit(): void {
    console.log(this.form.basic);
  }

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.phoneBookService
      .getAll(this.search)
      .pipe(takeUntil(this.onDestroy))
      .subscribe(
        (result) => {
          this.users = result.result;
          this.toastrService.success("success");
        },
        (error) => {
          this.toastrService.error(error);
        }
      );
  }

  onAdd() {
    this.form.model = new PhoneBook();
    this.form.openModal();
  }
  onEdit() {
    this.form.model = this.selected[0];
    this.form.openModal();
  }
  onDelete() {
    this.phoneBookService.delete(this.selected[0].id).subscribe(
      (res) => {
        const index = this.users.findIndex((f) => f.id == this.selected[0].id);
        this.users.splice(index, 1);
      },
      (err) => {
        this.toastrService.error(err);
      }
    );
  }

  save(phoneModel: PhoneBook) {
    console.log(phoneModel.id > 0);
    phoneModel.id > 0 ? this.edit(phoneModel) : this.add(phoneModel);
  }

  add(phoneModel: PhoneBook) {
    this.phoneBookService.create(phoneModel).subscribe(
      (res) => {
        this.users.push(res.body as PhoneBook);
        this.onSuccesCloseModal();
        this.toastrService.success("Success");
      },
      (err) => {
        this.toastrService.error(err);
      }
    );
  }

  edit(phoneModel: PhoneBook) {
    this.phoneBookService.update(phoneModel).subscribe(
      (res) => {
        const index = this.users.findIndex((f) => f.id == res.body["id"]);
        this.users.splice(index, 1);
        this.users.push(res.body as PhoneBook);
        this.onSuccesCloseModal();
      },
      (err) => {
        this.toastrService.error(err);
      }
    );
  }

  onSuccesCloseModal() {
    this.form.closeModal();
  }
}
