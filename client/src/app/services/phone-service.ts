import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PhoneModel } from '../models/phone-model';

@Injectable({
  providedIn: 'root'
})
export class PhoneService {

  private apiUrl = 'http://localhost:5248/api/PhoneModel';

  constructor(private http: HttpClient) {}
  

  
  getAll(): Observable<PhoneModel[]> {
  return this.http.get<PhoneModel[]>(this.apiUrl);
}

  get(id: number): Observable<PhoneModel> {
    return this.http.get<PhoneModel>(`${this.apiUrl}/${id}`);
  }

  create(phone: PhoneModel): Observable<PhoneModel> {
    return this.http.post<PhoneModel>(this.apiUrl, phone);
  }

  update(id: number, phone: PhoneModel): Observable<PhoneModel> {
    return this.http.put<PhoneModel>(`${this.apiUrl}/${id}`, phone);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
