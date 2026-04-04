# Service-test-backstage

A .NET 8 Hello World service ready to run on Amazon ECS Fargate, created via the SWIVEL Engineering golden path template.

## What's included

| Path | Purpose |
|------|---------|
| `src/Service-test-backstage/` | ASP.NET Core minimal API |
| `Dockerfile` | Multi-stage Docker build |
| `ecs/task-definition.json` | ECS Fargate task definition |
| `.github/workflows/deploy-ecs.yml` | GitHub Actions CI/CD pipeline |

## Run locally

```bash
dotnet restore
dotnet run --project src/Service-test-backstage/Service-test-backstage.csproj
```

Open http://localhost:8080 — you should see:

```json
{"service":"Service-test-backstage","message":"Hello World from .NET 8 running on ECS"}
```

## Build and run with Docker

```bash
docker build -t service-test-backstage:local .
docker run --rm -p 8080:8080 service-test-backstage:local
```

## CI/CD Pipeline

The GitHub Actions workflow (`.github/workflows/deploy-ecs.yml`) runs on every push to `main`:

1. Authenticate to AWS via OIDC (no long-lived credentials)
2. Build and push Docker image to ECR
3. Render ECS task definition with new image digest
4. Deploy to ECS service and wait for stability

### Prerequisites

- ECR repository: `dotnet-hello-world`
- ECS cluster: `my-ecs-cluster`
- ECS service: `my-dotnet-service`
- GitHub OIDC role: `test`

## Endpoints

- `GET /` — Hello World JSON response
- `GET /health` — Health check
