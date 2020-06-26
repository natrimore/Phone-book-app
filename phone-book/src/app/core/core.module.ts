import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule, HttpClient } from "@angular/common/http";
import { ToastrModule } from "ngx-toastr";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

/**
 * Modules imported by CoreModule
 */
const IMPORTS = [
  CommonModule,
  BrowserModule,
  BrowserAnimationsModule,
  HttpClientModule,
  ToastrModule.forRoot({
    timeOut: 3000,
    positionClass: "toast-bottom-right",
  }),
];

/**
 * Module declarations(components)
 */
const DECLARATIONS = [];

/**
 *  Module exporting modules
 */
const EXPORTS = [CommonModule, BrowserModule, BrowserAnimationsModule];

@NgModule({
  imports: [...IMPORTS],
  declarations: [...DECLARATIONS],
  exports: [...EXPORTS],
  providers: [],
})
export class CoreModule {}
