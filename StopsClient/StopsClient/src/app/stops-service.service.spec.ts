import { TestBed } from '@angular/core/testing';

import { StopsServiceService } from './stops-service.service';

describe('StopsServiceService', () => {
  let service: StopsServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StopsServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
