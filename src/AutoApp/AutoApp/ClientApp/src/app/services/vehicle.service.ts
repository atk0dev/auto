import { SaveVehicle } from './../models/vehicle';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  private readonly vehiclesEndpoint = '/api/vehicles';

  constructor(private http: HttpClient) { }

  getMakes(): Observable<any> {
    return this.http.get('/api/makes');
  }

  getFeatures(): Observable<any> {
    return this.http.get('/api/features');
  }

  create(vehicle){
    return this.http.post(this.vehiclesEndpoint, vehicle);
  }

  update(vehicle: SaveVehicle) {
    return this.http.put(this.vehiclesEndpoint + '/' + vehicle.id, vehicle);
  }

  delete(id: number) {
    return this.http.delete(this.vehiclesEndpoint + '/' + id);
  }

  getVehicle(id) {
    return this.http.get(this.vehiclesEndpoint + '/' + id);
  }

  getVehicles(filter) {
    return this.http.get(this.vehiclesEndpoint + '?' + this.toQueryString(filter));
  }

  toQueryString(obj) {
    var parts = [];
    for (var property in obj) {
      var value = obj[property];
      if (value != null && value != undefined)
        parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
    }

    return parts.join('&');
  }

}
