import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Investor } from '../models/investor.model';
import { Commitment } from '../models/commitment.model';

@Injectable({
  providedIn: 'root'
})
export class InvestorService {
  private apiUrl = 'https://localhost:44360/api/Investors'; // Adjust based on your backend URL

  constructor(private http: HttpClient) {}

  // Get all investors
  getInvestors(): Observable<Investor[]> {
    return this.http.get<Investor[]>(this.apiUrl);
  }

  // Get commitments for a specific investor
  getInvestorCommitments(investorId: number, assetClass?: string): Observable<Commitment[]> {
    let params = new HttpParams();
    if (assetClass) {
      params = params.set('assetClass', assetClass);
    }
    return this.http.get<Commitment[]>(`${this.apiUrl}/${investorId}/commitments`, { params });
  }
}