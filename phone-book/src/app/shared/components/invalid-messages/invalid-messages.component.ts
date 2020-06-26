import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-invalid-messages',
  templateUrl: './invalid-messages.component.html',
  styleUrls: ['./invalid-messages.component.scss']
})
export class InvalidMessagesComponent implements OnInit {
  @Input() submitted = false;
  @Input() field: any;

  constructor() { }

  ngOnInit() {
  }

}
