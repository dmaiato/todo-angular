
export interface Task {
    id: number;
    title: string;
    description: string;
    status: 'A fazer' | 'Em Andamento' | 'Concluído';
}