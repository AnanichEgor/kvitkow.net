import { TestBed } from '@angular/core/testing';

import { DeleteTicketByIdService } from './delete-ticket-by-id.service';

describe('DeleteTicketByIdService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DeleteTicketByIdService = TestBed.get(DeleteTicketByIdService);
    expect(service).toBeTruthy();
  });
});
