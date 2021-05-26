import { TestBed } from '@angular/core/testing';

import { DatatransferserviceService } from './datatransferservice.service';

describe('DatatransferserviceService', () => {
  let service: DatatransferserviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DatatransferserviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
