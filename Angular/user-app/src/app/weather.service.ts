import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Weather } from './weather';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {
  baseUrl = 'https://localhost:44302/WeatherForecast';
  httpOptions = {
    headers: new HttpHeaders({
      Authorization: `Bearer ${JSON.parse(localStorage.getItem('user') || '{}').token}`
    })
  };
  constructor(private http: HttpClient) { }

  getWeatherForeCast(){
    return this.http.get<Weather[]>(this.baseUrl, this.httpOptions);
  }
}
