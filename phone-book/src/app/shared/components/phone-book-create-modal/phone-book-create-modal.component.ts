import { Component, OnInit, Output, EventEmitter } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { PhoneBook } from "src/app/core/models/phone-book/phone-book";

@Component({
  selector: "app-phone-book-create-modal",
  templateUrl: "./phone-book-create-modal.component.html",
  styleUrls: ["./phone-book-create-modal.component.css"],
})
export class PhoneBookCreateModalComponent implements OnInit {
  basic = false;

  model: PhoneBook;
  form: FormGroup;
  submitted = false;

  @Output() save = new EventEmitter();

  constructor(private fb: FormBuilder) {}

  ngOnInit() {
    this.model = new PhoneBook();
    this.initForm(this.model);
  }

  initForm(model: PhoneBook) {
    this.form = this.fb.group({
      id: [model.id || 0],
      phoneNumber: [model.phoneNumber, [Validators.required]],
      userName: [model.userName],
    });

    console.log(this.form);
  }

  openModal() {
    this.initForm(this.model);
    this.basic = true;
  }

  closeModal() {
    this.basic = false;
    this.form.reset();
  }

  submit() {
    this.submitted = true;
    if (this.form.invalid) return;

    this.save.emit(this.form.value);
  }
}
