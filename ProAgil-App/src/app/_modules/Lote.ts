export interface Lote {

    loteId: number;
    nome: string;
    preco: number;
    dataInicio?: Date;
    dataFim?: Date;
    quatidade: number;
    eventoId: number;
}
