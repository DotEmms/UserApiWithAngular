import { Component, OnInit } from '@angular/core';
import { Weather } from '../weather';
import { WeatherService } from '../weather.service';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})
export class WeatherComponent implements OnInit {
  forecasts : Weather[] | undefined
  constructor(private weatherService : WeatherService) { }

  ngOnInit(): void {
    this.loadForecasts();
  }
  loadForecasts(){
    this.weatherService.getWeatherForeCast().subscribe(forecasts => {this.forecasts = forecasts});
  }
}
