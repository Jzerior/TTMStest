import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { PhonePage } from './pages/phone-page/phone-page';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,PhonePage],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected title = 'client';
}
