﻿using System;
using System.Net;
using NGitLab.Models;

namespace NGitLab.Mock.Clients
{
    internal sealed class FileClient : ClientBase, IFilesClient
    {
        private readonly int _projectId;

        public FileClient(ClientContext context, int projectId)
            : base(context)
        {
            _projectId = projectId;
        }

        public void Create(FileUpsert file)
        {
            var project = GetProject(_projectId, ProjectPermission.Contribute);
            var commitCreate = new CommitCreate
            {
                Branch = file.Branch,
                CommitMessage = file.CommitMessage,
                AuthorEmail = Context.User.Email,
                AuthorName = Context.User.Name,
                ProjectId = _projectId,
                Actions = new[]
                {
                    new CreateCommitAction()
                    {
                        Action = nameof(CommitAction.Create),
                        Content = file.Content,
                        Encoding = file.Encoding,
                        FilePath = file.Path,
                    },
                },
            };

            project.Repository.Commit(commitCreate);
        }

        public void Delete(FileDelete file)
        {
            var project = GetProject(_projectId, ProjectPermission.Contribute);
            var commitCreate = new CommitCreate
            {
                Branch = file.Branch,
                CommitMessage = file.CommitMessage,
                AuthorEmail = Context.User.Email,
                AuthorName = Context.User.Name,
                ProjectId = _projectId,
                Actions = new[]
                {
                    new CreateCommitAction()
                    {
                        Action = nameof(CommitAction.Delete),
                        FilePath = file.Path,
                    },
                },
            };

            project.Repository.Commit(commitCreate);
        }

        public FileData Get(string filePath, string @ref)
        {
            var fileSystemPath = WebUtility.UrlDecode(filePath);

            var project = GetProject(_projectId, ProjectPermission.View);
            return project.Repository.GetFile(fileSystemPath, @ref);
        }

        public bool FileExists(string filePath, string @ref)
        {
            return Get(filePath, @ref) != null;
        }

        public Blame[] Blame(string filePath, string @ref)
        {
            throw new NotImplementedException();
        }

        public void Update(FileUpsert file)
        {
            var project = GetProject(_projectId, ProjectPermission.Contribute);
            var commitCreate = new CommitCreate
            {
                Branch = file.Branch,
                CommitMessage = file.CommitMessage,
                AuthorEmail = Context.User.Email,
                AuthorName = Context.User.Name,
                ProjectId = _projectId,
                Actions = new[]
                {
                    new CreateCommitAction()
                    {
                        Action = nameof(CommitAction.Update),
                        Content = file.Content,
                        Encoding = file.Encoding,
                        FilePath = file.Path,
                    },
                },
            };

            project.Repository.Commit(commitCreate);
        }
    }
}