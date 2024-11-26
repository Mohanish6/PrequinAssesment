import { Component, OnInit } from '@angular/core';
import { InvestorService } from '../../services/investor.service';
import { Investor } from '../../models/investor.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-investor-list',
  templateUrl: './investor-list.component.html',
  styleUrls: ['./investor-list.component.css'],
  imports: [CommonModule],
})
export class InvestorListComponent implements OnInit {
  investors: Investor[] = []; // List of investors
  selectedInvestorId?: number; // ID of the selected investor
  error: string = '';         // Error message (if any)

  constructor(private investorService: InvestorService) {}

  ngOnInit(): void {
    this.fetchInvestors();
  }

  // Fetch the list of investors from the API
  fetchInvestors(): void {
    this.investorService.getInvestors().subscribe({
      next: (data) => {
        this.investors = data;
      },
      error: (err) => {
        console.error('Error fetching investors:', err);
        this.error = 'Failed to fetch investors.';
      }
    });
  }

  // Handle investor selection
  onSelectInvestor(investorId: number): void {
    this.selectedInvestorId = investorId;
    console.log('Selected Investor ID:', investorId);
    // You can now fetch commitments or handle navigation
  }
}