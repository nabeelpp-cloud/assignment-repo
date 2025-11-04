import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TableCreation } from "./table-creation/table-creation";
import { LinkCreation } from "./link-creation/link-creation";
import { ListCreation } from "./list-creation/list-creation";
import { NestedListCreation } from "./nested-list-creation/nested-list-creation";
import { AlertButtonCreation } from "./alert-button-creation/alert-button-creation";
import { LeapYearFinder } from "./leap-year-finder/leap-year-finder";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, TableCreation, LinkCreation, ListCreation, NestedListCreation, AlertButtonCreation, LeapYearFinder],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('angularDay1');
}
