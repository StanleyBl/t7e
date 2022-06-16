import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { NavigationBar } from '../../models/navigation';

@Injectable({
  providedIn: 'root'
})
export class NavigationService {
  navigation$: BehaviorSubject<NavigationBar> = new BehaviorSubject<NavigationBar>(null);

  constructor() { }
}
