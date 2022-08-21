export class product {
  constructor(
    public name: string,
    public unit: string,
    public amount: number,
    public priority: boolean,
    public deliveryDate: Date
  ) {
  }
}
