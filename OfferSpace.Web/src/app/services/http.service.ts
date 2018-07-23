import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class HttpService {
  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public get(url: string): Observable<Object> {
    return this.http.get(this.baseUrl + url);
  }

  public post(url: string, object: any): Observable<Object> {
    return this.http.post(this.baseUrl + url, object);
  }

  public put(url: string, object: any): Observable<Object> {
    console.log(this.baseUrl + url);
    return this.http.put(this.baseUrl + url, object);
  }

  public delete(url: string): Observable<Object> {
    console.log(this.baseUrl + url);
    return this.http.delete(this.baseUrl + url);
  }
}
