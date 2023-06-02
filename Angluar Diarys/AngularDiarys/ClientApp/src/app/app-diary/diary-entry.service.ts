import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DiaryEntry } from './diaryEntry.model';

@Injectable()
export class DiaryEntryService {
  private apiUrl = '/api/DiaryEntries';

  constructor(private http: HttpClient) { }

  getDiaryEntries(): Observable<DiaryEntry[]> {
    return this.http.get<DiaryEntry[]>(this.apiUrl);
  }

  getDiaryEntry(id: number): Observable<DiaryEntry> {
    return this.http.get<DiaryEntry>(`${this.apiUrl}/${id}`);
  }

  addDiaryEntry(entry: DiaryEntry): Observable<DiaryEntry> {
    return this.http.post<DiaryEntry>(this.apiUrl, entry);
  }

  deleteDiaryEntry(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
