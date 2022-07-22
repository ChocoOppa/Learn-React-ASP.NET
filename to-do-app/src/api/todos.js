import axiosClient from './axiosClient';

const END_POINT = {
    TODOS: '/Todos',
}

export const getTodos = () => {
    return axiosClient.get(`${END_POINT.TODOS}`);
}

export const deleteTodo = (id) => {
    return axiosClient.delete(`${END_POINT.TODOS}/${id}`);
}

export const addTodo = (todo) => {
    return axiosClient.post(`${END_POINT.TODOS}`, todo);
}

export const updateTodo = (todo) => {
    return axiosClient.put(`${END_POINT.TODOS}/${todo.id}`, todo);
}