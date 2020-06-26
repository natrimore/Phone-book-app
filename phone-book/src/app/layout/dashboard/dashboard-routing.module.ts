import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { DashboardComponent } from "./dashboard.component";
import { PhoneBookComponent } from "./pages/phone-book/phone-book.component";

/**
 *
 */
const routes: Routes = [
  {
    path: "",
    component: DashboardComponent,
    // redirectTo: "dashboard",
    // pathMatch: "full",
    children: [
      {
        path: "phone-book",
        component: PhoneBookComponent,
      },
    ],
  },
];

/**
 *
 */
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DashboardRoutingModule {}
