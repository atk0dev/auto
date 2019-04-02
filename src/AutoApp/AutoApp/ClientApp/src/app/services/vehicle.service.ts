import { SaveVehicle } from './../models/vehicle';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  constructor(private http: HttpClient) { }

  getMakes(): Observable<any> {
    return this.http.get('/api/makes');
  }

  getFeatures(): Observable<any> {
    return this.http.get('/api/features');
  }

  create(vehicle){
    return this.http.post('/api/vehicles', vehicle);
  }

  update(vehicle: SaveVehicle) {
    return this.http.put('/api/vehicles/' + vehicle.id, vehicle);
  }

  delete(id: number) {
    return this.http.delete('/api/vehicles/' + id);
  }

  getVehicle(id) {
    return this.http.get('/api/vehicles/' + id);
  }
}
