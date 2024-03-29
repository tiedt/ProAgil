import { RedeSocial } from './RedeSocial';
import { Evento } from './Evento';

export interface Palestrante {

    palestranteId: number;
    nome: string;
    miniCurriculo: string;
    imagemURL: string;
    telefone: string;
    email: string;
    redesSociais: RedeSocial[];
    palestranteEventos: Evento[];
}
