import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule} from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventosComponent } from './eventos/eventos.component';
import { NavComponent } from './nav/nav.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TooltipModule} from 'ngx-bootstrap/tooltip';
import { BsDropdownModule} from 'ngx-bootstrap/dropdown';
import { ModalModule} from 'ngx-bootstrap/modal';
import { EventoService } from './_services/evento.service';
import { DateTimeFormatPipe } from './_helps/DateTimeFormatPipe.pipe';
import {BsDatepickerModule} from 'ngx-bootstrap/datepicker';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PalestrantesComponent } from './palestrantes/palestrantes.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ContatosComponent } from './contatos/contatos.component';
import { TituloComponent } from './_shared/titulo/titulo.component';

@NgModule({
   declarations: [
      AppComponent,
      PalestrantesComponent,
      DashboardComponent,
      ContatosComponent,
      EventosComponent,
      NavComponent,
      DateTimeFormatPipe,
      PalestrantesComponent,
      DashboardComponent,
      ContatosComponent,
      TituloComponent,
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      BsDatepickerModule.forRoot(),
      BsDropdownModule.forRoot(),
      TooltipModule.forRoot(),
      ModalModule.forRoot(),
      ToastrModule.forRoot(),
      BrowserAnimationsModule,
      ReactiveFormsModule
   ],
   providers: [
      EventoService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
