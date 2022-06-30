import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-status-bar',
  templateUrl: './status-bar.component.html',
  styleUrls: ['./status-bar.component.scss']
})
export class StatusBarComponent implements OnInit {

  @Input() percent = 0;
  @Input() label = '';

  percentView = 0;

  constructor() { }

  ngOnInit(): void {
    setTimeout(() => {
      this.percentView = this.percent;
    }, 100);
  }

}
