import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { InvestorListComponent } from './components/investor-list/investor-list.component';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, InvestorListComponent, CommonModule, HttpClientModule], // Added HttpClientModule
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'] // Corrected 'styleUrl' to 'styleUrls'
})
export class AppComponent {
  title = 'investor-commitments';
}