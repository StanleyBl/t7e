import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NavigationBar, NavigationItem } from 'src/app/core/models/navigation';
import { NavigationService } from 'src/app/core/services/internal/navigation.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit {

  items: NavigationItem[] = [];
  change = false;

  barItems: NavigationBar;

  constructor(public navigationService: NavigationService,
    private router: Router) { 
    this.navigationService.navigation$.subscribe(bar => {
      this.applyNavigation(bar);
    });
  }

  ngOnInit(): void {
  }

  applyNavigation(bar: NavigationBar) {
    this.change = true;

    setTimeout(() => {
      this.barItems = bar;
    }, 500);

    setTimeout(() => {
      this.change = false;
    }, 1000);
  }

  onClick(item: NavigationItem) {
    if (item.action) {
      item.action();
      return;
    }

    if (item.route) {
      this.router.navigate([item.route]);
      return;
    }
  }
}
