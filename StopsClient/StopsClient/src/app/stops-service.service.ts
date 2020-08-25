import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { Stops } from './stops';
import { HttpParams } from "@angular/common/http";
@Injectable({
  providedIn: 'root'
})
export class StopsServiceService {

  constructor(private httpClient:HttpClient) 
  { 


  }
  getAllStops(stop): Observable<Stops[]>
  {
    let params = new HttpParams();
    params = params.append('stop', stop);
    return this.httpClient.get<Stops[]>("https://localhost:5001/api/stops?stop=" + stop);
  }
}
