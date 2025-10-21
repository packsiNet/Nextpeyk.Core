﻿namespace ApplicationLayer.Dto.BaseDtos;

public class PaginationDto
{
    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 10;

    public int Skip => (Page - 1) * PageSize;
}