import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonService {
  private apiUrl = 'http://localhost:5001/api/person'; 

  constructor(private http: HttpClient) { }

  addPerson(person: { name: string, address: string }): Observable<any> {
    return this.http.post(this.apiUrl, person);
  }
}
