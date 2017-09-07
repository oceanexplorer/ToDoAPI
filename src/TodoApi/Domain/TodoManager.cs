using System;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;

namespace TodoApi.Domain
{
    public class TodoManager
    {
        private readonly TodoContext _context;
        
        public TodoManager(TodoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _context.TodoItems.ToList();
        }

        public TodoItem GetById(long id)
        {
            return _context.TodoItems.FirstOrDefault(t => t.Id == id);
        }    

        public void Add(TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();  
        }

        public void Update(TodoItem item)
        {
            var todo = _context.TodoItems.FirstOrDefault(t => t.Id == item.Id);
                        
            todo.IsComplete = item.IsComplete;
            todo.Name = item.Name;

            _context.TodoItems.Update(todo);
            _context.SaveChanges();           
        }

        public void Remove(long id)
        {
            var todo = _context.TodoItems.First(t => t.Id == id);
            
            if(todo != null)
            {
                _context.TodoItems.Remove(todo);
                _context.SaveChanges();
            }
        }
    }
}