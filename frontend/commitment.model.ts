export interface Commitment {
    id: number;                 // Unique identifier for the commitment
    investorId: number;         // The associated investor's ID
    assetClass: string;         // Type of asset class (e.g., Real Estate, Private Equity)
    amount: number;             // The amount committed for the asset class
  }