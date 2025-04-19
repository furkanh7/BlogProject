using Blog.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.FluentValidations
{
    public class ArticleValidator: AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .WithName("Ba�l�k")
                .WithMessage("Title cannot be empty")
                .Length(3, 160);
            //.WithMessage("Title must be between 5 and 100 characters");
            RuleFor(x => x.Content)
                .NotEmpty()
                .NotNull()
                .WithName("��erik")
                .WithMessage("Content cannot be empty")
                .Length(3, 1000);
            //.WithMessage("Content must be between 5 and 100 characters");



        }


    }
}
