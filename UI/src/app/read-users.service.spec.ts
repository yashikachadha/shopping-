import { TestBed } from '@angular/core/testing';

import { ReadUsersService } from './read-users.service';

describe('ReadUsersService', () => {
  let service: ReadUsersService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ReadUsersService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
