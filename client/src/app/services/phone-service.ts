import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PhoneModel } from '../models/phone-model';

@Injectable({
  providedIn: 'root'
})
export class PhoneService {

  private apiUrl = 'http://localhost:5262/api/phone';

  constructor(private http: HttpClient) {}
  

  
  getAll(): Observable<PhoneModel[]> {
  return this.http.get<PhoneModel[]>(this.apiUrl);
}

  get(id: string): Observable<PhoneModel> {
    return this.http.get<PhoneModel>(`${this.apiUrl}/${id}`);
  }

  create(phone: PhoneModel): Observable<PhoneModel> {
    return this.http.post<PhoneModel>(this.apiUrl, phone);
  }

  update(id: string, phone: PhoneModel): Observable<PhoneModel> {
    return this.http.put<PhoneModel>(`${this.apiUrl}/${id}`, phone);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
