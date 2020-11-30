import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { FooterSectionComponent } from './footer-section/footer-section.component';
import { HomeComponent } from './skala/inicio/inicio.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ModalInfoComponent } from './@base/modales/modal-info/modal-info.component';
import { RegistroComponent } from './skala/registro/registro.component';
import { AlertaModalErrorComponent } from './@base/alerta-modal-error/alerta-modal-error.component';
import { AlertaModalOkComponent } from './@base/alerta-modal-ok/alerta-modal-ok.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    CounterComponent,
    FetchDataComponent,
    FooterSectionComponent,
    HomeComponent,
    ModalInfoComponent,
    RegistroComponent,
    AlertaModalErrorComponent,
    AlertaModalOkComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ]),
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
