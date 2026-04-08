import { TestBed } from '@angular/core/testing';

import { Auth } from './auth';

describe('Auth', () => {
  private apiUrl = 'https://localhost:7128/api/auth';

  constructor(private http: HttpClient) {}

  login(email: string, password: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, {
      email: email,
      password: password
    });
  }
});
