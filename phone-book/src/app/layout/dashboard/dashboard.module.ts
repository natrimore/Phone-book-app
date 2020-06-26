import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { DashboardRoutingModule } from "./dashboard-routing.module";

import { DashboardComponent } from "./dashboard.component";
import {
  ClrVerticalNavModule,
  ClrDatagridModule,
  ClrInputModule,
} from "@clr/angular";
import { PhoneBookComponent } from "./pages/phone-book/phone-book.component";
import { DashboardHeaderComponent } from "./components/dashboard-header/dashboard-header.component";
import { DashboardSidebarComponent } from "./components/dashboard-sidebar/dashboard-sidebar.component";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { SharedModule } from "src/app/shared/shared.module";

/**
 *
 */
@NgModule({
  declarations: [
    DashboardComponent,
    PhoneBookComponent,
    DashboardHeaderComponent,
    DashboardSidebarComponent,
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    SharedModule,
    ReactiveFormsModule,
    FormsModule,
  ],
})
export class DashboardModule {}
