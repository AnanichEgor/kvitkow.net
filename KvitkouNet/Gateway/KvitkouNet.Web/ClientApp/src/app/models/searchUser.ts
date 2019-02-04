export class SearchUser {
  limit: number;
  offset: number;
  rating?: number;

  public constructor(init?: Partial<SearchUser>) {
    Object.assign(this, init);
  }
}
