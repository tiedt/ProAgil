import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Evento } from '../_modules/Evento';

@Injectable({
  providedIn: 'root'
})
export class EventoService {
  baseUrl = 'https://localhost:5001/evento';
  constructor(private http: HttpClient) { }

  getAllEventos(): Observable<Evento[]> {
    return this.http.get<Evento[]>(this.baseUrl);
  }
  getEventoByTema(tema: string): Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.baseUrl}/getByTema/${tema}`);
  }
  getEventoById(id: number): Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.baseUrl}/${id}`);
  }
  postEvento(evento: Evento) {
    return this.http.post(`${this.baseUrl}`, evento);
  }
  putEvento(evento: Evento): Observable<any> {
    return this.http.put(`${this.baseUrl}/${evento.eventoId}`, evento);
  }
  deleteEvento(id: number): Observable<any>{
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
