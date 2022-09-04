import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Doctor } from '../_models/doctor';

// const httpOptions = {
//   headers: new HttpHeaders({
//     Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('patient')).token
//   })
// }
@Injectable({
  providedIn: 'root'
})
export class MembersService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getDoctors(): Observable<Doctor[]>{
    return this.http.get<Doctor[]>(this.baseUrl + 'doctors');
  }

  getDoctor(id: number){
    return this.http.get<Doctor>(this.baseUrl + 'doctors/' + id);
  }
}
