import { Injectable, Inject } from '@angular/core'
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable, from } from 'rxjs'
import { tap, catchError } from 'rxjs/operators'
import { Persona } from '../skala/models/persona'
import { HandleHttpErrorService } from '../@base/handle-http-error.service'

const httpOptionsPut = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  responseType: 'text'
};

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root',
})
export class PersonaService {
  baseUrl: string
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService,
  ) {
    this.baseUrl = baseUrl
  }
  post(persona: Persona): Observable<Persona> {
    return this.http
      .post<Persona>(this.baseUrl + 'api/persona', persona)
      .pipe(
        tap((_) => this.handleErrorService.logOk('Persona registrada con éxito')),
        catchError(
          this.handleErrorService.handleError<Persona>(
            'Registro del prodcutor',
            null,
          ),
        ),
      )
  }
}
