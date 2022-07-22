import { useEffect, useRef, useState } from "react";
import { getTodos, deleteTodo, addTodo, updateTodo } from "../api/todos";

const Todos = () => {
    const [todos, setTodos] = useState([]);
    const [textButton, setTextButton] = useState('Add Todo');
    const todoRef = useRef([]);
    
    useEffect(() => {
      fetchData();
    
    }, []);

    const fetchData = async () => {
        setTodos(await getTodos());
    };

    const delTodo = async (id) => {
        if(window.confirm("Are you sure you want to delete this todo?")) {
            await deleteTodo(id);
            setTodos(await getTodos());
        }
    }

    const addOrEditTodo = async (event) => {
        event.preventDefault();
        const val = event.target[0].value;
        const id = event.target[1].value;
        console.log({val, id});

        if(id) {
            // Update
            await updateTodo({
                id: id,
                name: val});
            todoRef.current[id].className = 'fas fa-edit';
        } else {
            // New
            await addTodo({
                name: val,
            })
            
        }
        setTodos(await getTodos());
        event.target[0].value = '';
        event.target[1].value = null;
        setTextButton('Add Todo');
    }

    const editTodo = async (id) => {
        todoRef?.current.forEach((todo) => {
            if(todo.getAttribute('data-id') && todo.getAttribute('data-id') !== String(id)) {
                todo.className = 'fas fa-edit';
            }
        })

        const inputName = document.getElementById(`name`);
        const inputId = document.getElementById(`id`);
        if(todoRef?.current[id].className === 'fas fa-edit') {
            setTextButton('Update Todo');
            inputName.value = todoRef.current[id].getAttribute('data-name');
            inputId.value = id;
            todoRef.current[id].className = 'fas fa-user-edit';
        } else if(todoRef?.current[id].className === 'fas fa-user-edit') {
            setTextButton('Add Todo');
            todoRef.current[id].className = 'fas fa-edit';
            inputName.value = '';
            inputId.value = null;
        }
    }

    const completeToDo = async (todo) => {
        await updateTodo({
            ...todo, isComplete: !todo.isComplete
        })
        setTodos(await getTodos());
    }

  return (
    <main id="todolist">
        <h1>
            Danh sách
            <span>Việc hôm nay không để ngày mai.</span>
        </h1>

        {
            todos ?
            todos?.map((todo, id) => (
                <li className={todo.isComplete ? "done" : ""} key={id} onDoubleClick={() => completeToDo(todo)}>
                    <span className="label">{todo.name}</span>
                    <div className="actions">
                        <button 
                        className="btn-picto" 
                        type="button"
                        onClick={() => editTodo(todo.id)}>
                            <i 
                            className="fas fa-edit"
                            ref={element => todoRef.current[todo.id] = element}
                            data-name={todo.name}
                            data-id={todo.id}
                            ></i>
                        </button>
                        <button 
                        className="btn-picto" 
                        type="button" 
                        aria-label="Delete" 
                        title="Delete"
                        onClick={() => delTodo(todo.id)}>
                            <i className="fas fa-trash"></i>
                        </button>
                    </div>
                </li>
            ))
:
            <p>Danh sách nhiệm vụ trống.</p>
        }

        
        {/* <li>
            <span className="label">123</span>
            <div className="actions">
                <button className="btn-picto" type="button">
                    <i className="fas fa-user-edit"></i>
                </button>
                <button className="btn-picto" type="button" aria-label="Delete" title="Delete">
                    <i className="fas fa-trash"></i>
                </button>
            </div>
        </li> */}

        <form onSubmit={addOrEditTodo}>
            <label htmlFor="name">Thêm nhiệm vụ mới</label>
            <input type="text" name="name" id="name"/>
            <input type="text" name="id" id="id" style={{display: 'none'}}/>
            <button type="submit">{textButton}</button>
        </form>
    </main>
  )
}

export default Todos