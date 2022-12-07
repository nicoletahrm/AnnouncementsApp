import { Injectable, ViewChild } from '@angular/core';
import { Announcement } from '../announcement';
import { Category } from '../category';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AnnouncementService {
  constructor(private http: HttpClient) {}

  baseURL = 'https://newsapi20221108120432.azurewebsites.net/api/Announcements';

  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  serviceCall() {
    console.log('Service was called');
  }

  getAnnouncements(): Observable<Announcement[]> {
    return this.http.get<Announcement[]>(this.baseURL);
  }

  postAnnouncement(announcement: Announcement): Observable<Announcement> {
    return this.http.post<Announcement>(
      this.baseURL,
      announcement,
      this.httpOptions
    );
  }

  deleteAnnouncement(id: string): Observable<Announcement> {
    return this.http.delete<Announcement>(this.baseURL + '/' + id);
  }
}
