import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs/Subject';
import { BrowserXhr } from "@angular/http";

@Injectable({
  providedIn: 'root'
})
export class ProgressService {
  uploadProgress: Subject<any> = new Subject();
  downloadProgress: Subject<any> = new Subject();

  constructor(private http: HttpClient) { }
}


@Injectable({
  providedIn: 'root'
})
export class BrowserXhrWithProgress extends BrowserXhr {

  uploadProgress: Subject<any> = new Subject();
  downloadProgress: Subject<any> = new Subject();

  constructor(private http: HttpClient) { }

}
