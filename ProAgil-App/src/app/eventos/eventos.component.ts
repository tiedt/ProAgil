import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventoService } from '../_services/evento.service';
import { Evento } from '../_modules/Evento';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { BsLocaleService, } from 'ngx-bootstrap/datepicker';
import { ptBrLocale } from 'ngx-bootstrap/locale';
import { templateJitUrl } from '@angular/compiler';
import { ToastrService } from 'ngx-toastr';
defineLocale('pt-br', ptBrLocale);
@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  eventos: Evento[];
  evento: Evento;
  eventosFiltrados: Evento[];
  imagemLargura = 50;
  imagemMargem = 2;
  mostrarImagem = false;
  _filtroLista = '';
  registerForm: FormGroup;
  modoSalvar = 'post';
  bodyDeletarEvento = '';
  titulo = 'Eventos';
  idEvento: number;
  file: File;
  fileNameToUpdate: string;
  dataEvento: string;
  dataAtual: string;


  constructor(private eventoService: EventoService,
    private modalService: BsModalService,
    private fb: FormBuilder,
    private localeService: BsLocaleService,
    private toastr: ToastrService) {
    this.localeService.use('pt-br')
  }

  openModal(template: any) {
    this.registerForm.reset();
    template.show();
  }
  get filtroLista(): string {
    return this._filtroLista;
  }
  set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEvento(this.filtroLista) : this.eventos;
  }

  ngOnInit() {
    this.validation();
    this.getEventos();
  }
  filtrarEvento(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }
  editarEvento(evento: Evento, template: any) {
    this.modoSalvar = 'put';
    this.openModal(template);
    this.idEvento = evento.eventoId;
    this.evento = Object.assign({}, evento);
    this.fileNameToUpdate = evento.imagemURL.toString();
    this.evento.imagemURL = '';
    this.registerForm.patchValue(this.evento);
  }
  novoEvento(template: any) {
    this.modoSalvar = 'post';
    this.openModal(template);
  }
  alternarImagem() {
    this.mostrarImagem = !this.mostrarImagem;
  }
  excluirEvento(evento: Evento, template: any) {
    this.openModal(template);
    this.evento = evento;
    this.bodyDeletarEvento = `Tem certeza que deseja excluir o Evento: ${evento.tema}, Código: ${evento.tema}`;
  }
  confirmeDelete(template: any) {
    this.eventoService.deleteEvento(this.evento.eventoId).subscribe(
      () => {
        template.hide();
        this.getEventos();
        this.toastr.success('Deletado com Sucesso!');
      }, error => {
        this.toastr.error('Erro ao Tentar deletar!');
      }
    );
  }
  onChangeFile(event) {
    const reader = new FileReader();

    if (event.target.files && event.target.files.length) {
      this.file = event.target.files;
      console.log(this.file);
    }
  }
  uploadImagem() {
    if (this.modoSalvar === 'post') {
      const nomeArquivo = this.evento.imagemURL.split('\\', 3);
      this.evento.imagemURL = nomeArquivo[2];

      this.eventoService.postUpload(this.file, nomeArquivo[2])
        .subscribe(
          () => {
            this.dataAtual = new Date().getMilliseconds().toString();
            this.getEventos();
          }
        );
    } else {
      this.evento.imagemURL = this.fileNameToUpdate;
      this.eventoService.postUpload(this.file, this.fileNameToUpdate)
        .subscribe(
          () => {
            this.dataAtual = new Date().getMilliseconds().toString();
            this.getEventos();
          }
        );
    }
  }
  salvarAlteracao(template: any) {
    if (this.registerForm.valid) {
      if (this.modoSalvar === 'post') {
        this.evento = Object.assign({}, this.registerForm.value);
        this.uploadImagem();
        this.eventoService.postEvento(this.evento).subscribe(
          (novoEvento: Evento) => {
            template.hide();
            this.getEventos();
            this.toastr.success('Inserido com Sucesso!');
          }, error => {
            this.toastr.error(`Erro ao Inserir: ${error}`);
          }
        );
      } else {
        this.evento = Object.assign({ eventoId: this.idEvento }, this.registerForm.value);
        this.uploadImagem();
        this.eventoService.putEvento(this.evento).subscribe(
          () => {
            template.hide();
            this.getEventos();
            this.toastr.success('Editado com Sucesso!');
          }, error => {
            this.toastr.error(`Erro ao Editar: ${error}`);
          }
        );
      }
    }
  }
  validation() {
    this.registerForm = this.fb.group({
      tema: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      local: ['', Validators.required],
      dataEvento: ['', Validators.required],
      qtdPessoas: ['', [Validators.required, Validators.max(12220)]],
      telefone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      imagemURL: ['', Validators.required],
    });
  }
  getEventos() {
    this.dataAtual = new Date().getMilliseconds().toString();

    this.eventoService.getAllEventos().subscribe(
      (_eventos: Evento[]) => {
        this.eventos = _eventos;
        this.eventosFiltrados = this.eventos;
        console.log(this.eventos);
      }, error => {
        this.toastr.error(`Erro ao tentar Carregar eventos: ${error}`);
      });
  }
}
