using System;
using Microsoft.EntityFrameworkCore;
using TodoApi.Controllers;
using TodoApi.Models;
using Xunit;
using FluentAssertions;
using TodoApi.Domain;
using System.Linq;

namespace ToDoApi.Tests.Unit.TodoManagerContainer
{
    public class TodoManagerFacts
    {
        internal readonly TodoManager _sut;

        public TodoManagerFacts()
        {
            var context = GetInMemoryContext();
            _sut = new TodoManager(context);
        }

        private TodoContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<TodoContext>()
                        .UseInMemoryDatabase(Guid.NewGuid().ToString())
                        .Options;

            return new TodoContext(options);
        }
    }

    public class GetByIdMethod : TodoManagerFacts
    {
        [Fact]
        public void ReturnNullWhenNoTodosExist()
        {
            // Act
            var todo = _sut.GetById(1);

            // Assert
            todo.Should().BeNull();
        }

        [Fact]
        public void ReturnCorrectStoredTodo()
        {
            // Arrange
            var inputTodoItem = new TodoItem(1, "Take the bins out", false);
            _sut.Add(inputTodoItem);

            // Act
            var outputTodoItem = _sut.GetById(1);

            // Assert
            outputTodoItem.ShouldBeEquivalentTo(inputTodoItem);
        }
    }

    public class RemoveMethod : TodoManagerFacts
    {
        [Fact]
        public void RemoveExisitngTodo()
        {
            // Arrange
            var originalTodoItem = new TodoItem(1, "Go to the cinema", false);
            _sut.Add(originalTodoItem);

            // Act
            _sut.Remove(1);

            // Assert
            _sut.GetById(1).Should().BeNull();
        }            
    }

    public class AddMethod : TodoManagerFacts
    {
        [Fact]
        public void ShouldHaveCountOfOneWhenATodoItemIsAdded()
        {
            // Arrange
            var todoItem = new TodoItem("TestTodo", true);

            // Act 
            _sut.Add(todoItem);

            // Assert
            _sut.GetAll().Count().Should().Be(1);            
        }
    }

    public class UpdateMethod : TodoManagerFacts
    {
        [Fact]
        public void ShouldUpdateExisitingTodoItem()
        {
            // Arrange
            var originalTodoItem = new TodoItem(1, "Go to the cinema", false);
            var updatedToDoItem = new TodoItem(1, "Sing in the choir", true);
            _sut.Add(originalTodoItem);

            // Act
            _sut.Update(updatedToDoItem);

            // Assert
            _sut.GetById(1).ShouldBeEquivalentTo(updatedToDoItem);
        }
    }    
}
