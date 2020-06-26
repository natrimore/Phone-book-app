import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { SharedComponent } from "./shared.component";
import {
  ClrVerticalNavModule,
  ClrDatagridModule,
  ClrInputModule,
  ClrModalModule,
} from "@clr/angular";
import { PhoneBookCreateModalComponent } from "./components/phone-book-create-modal/phone-book-create-modal.component";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { NgxMaskModule } from "ngx-mask";
import { CoreModule } from "../core/core.module";

@NgModule({
  imports: [
    CommonModule,
    ClrVerticalNavModule,
    ClrDatagridModule,
    ClrVerticalNavModule,
    ClrDatagridModule,
    ClrInputModule,
    ClrModalModule,
    ReactiveFormsModule,
    NgxMaskModule.forRoot(),
    FormsModule,
  ],
  exports: [
    ClrVerticalNavModule,
    ClrDatagridModule,
    PhoneBookCreateModalComponent,
    ClrVerticalNavModule,
    ClrDatagridModule,
    ClrInputModule,
    ClrModalModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  declarations: [SharedComponent, PhoneBookCreateModalComponent],
  entryComponents: [],
})
export class SharedModule {}
